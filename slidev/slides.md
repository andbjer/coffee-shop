---
# You can also start simply with 'default'
theme: seriph
# random image from a curated Unsplash collection by Anthony
# like them? see https://unsplash.com/collections/94734566/slidev
background: https://cover.sli.dev
# some information about your slides (markdown enabled)
title: GraphQL - Better than the REST?
info: |
  ## Slidev Starter Template
  Presentation slides for developers.

  Learn more at [Sli.dev](https://sli.dev)
# apply unocss classes to the current slide
class: text-center
# https://sli.dev/features/drawing
drawings:
  persist: false
# slide transition: https://sli.dev/guide/animations.html#slide-transitions
transition: slide-left
# enable MDC Syntax: https://sli.dev/features/mdc
mdc: true
---

# GraphQL

Better than the REST?

<!--
The last comment block of each slide will be treated as slide notes. It will be visible and editable in Presenter Mode along with the slide. [Read more in the docs](https://sli.dev/guide/syntax.html#notes)
-->

---

# What is GraphQL?

GraphQL is a query language for APIs and a runtime for fulfilling those queries with your existing data

- Provides a complete and understandable description of the data in your API
- Gives client the power to retrieve only what they need
- Spec originally developed by Facebook
  - Is governed by the GraphQL Foundation

<br>

<div class="flex gap-1">
  <div class="flex-1">Query</div>
  <div class="flex-1">Response</div>
</div>
<div class="flex gap-1">
  <div class="flex-1">
```gql
{
  hero {
    name
  }
}
```
  </div>
  <div class="flex-1">
```json
{
  "hero": {
    "name": "Luke Skywalker"
  }
}
```
  </div>
</div>

<br>
<br>

Read more about [GraphQL](https://graphql.org/)

<!--
You can have `style` tag in markdown to override the style for the current page.
Learn more: https://sli.dev/features/slide-scope-style
-->

<style>
h1 {
  background-color: #2B90B6;
  background-image: linear-gradient(45deg, #4EC5D4 10%, #146b8c 20%);
  background-size: 100%;
  -webkit-background-clip: text;
  -moz-background-clip: text;
  -webkit-text-fill-color: transparent;
  -moz-text-fill-color: transparent;
}
</style>

<!--
Here is another comment.
-->

---

# The problem with REST

<br>

- Weak type enforcement (often JSON-based)
- Multiple network requests to get multiple resources
  1. `/users/<id>`
  2. `/users/<id>/posts`
  3. `/users/<id>/followers`
- Over and under-fetching (n +1 problem)
  - Multiple round trips for complex queries
- Often need to version to avoid breaking clients

---

# From REST to GraphQL

| Feature              | REST                                                       | GraphQL                                     |
| -------------------- | ---------------------------------------------------------- | ------------------------------------------- |
| **Endpoints**        | Multiple endpoints using GET / POST / PATCH / PUT / DELETE | Single endpoint using POST (`/graphql`)     |
| **Type system**      | Weak type enforcement                                      | Strongly typed schema with introspection    |
| **Performance**      | Can lead to over-fetching/under-fetching                   | Avoid overfetching, client specifies fields |
| **Breaking changes** | Versioning of API                                          | Deprecate fields that are no longer needed  |
| **Caching**          | Standard HTTP caching                                      | Caching is usually handled in client        |

---

# How does GraphQL work?

<div class="flex gap-3">
  <div class="flex-1">

```gql
schema {
  query: Query #required
  mutation: Mutation
  subscription: Subscription
}

type Query {
  hero: Character
}

type mutation {
  createReview(episode: Episode, review: ReviewInput!): Review
}

type Subscription {
  reviewCreated: Review
}
```

  </div>
  <div class="flex-1">
  
- Object types and fields

```gql
type Character { 
  name: String!
  appearsIn: [Episode!]!
}
```

- Scalar types - leaf values. 
  - `Int`, `Float`, `String`, `Boolean`, `ID`
- Enum types

```gql
enum Episode {
  NEWHOPE
  EMPIRE
  JEDI
}
```
  
  </div>
</div>


---

# How does GraphQL work?

- Interface types

<div class="flex gap-1">
  <div class="flex-1">
```gql
interface Character {
  id: ID!
  name: String!
}

type Human implements Character {
  id: ID!
  name: String!
  totalCredits: Int
}
 
type Droid implements Character {
  id: ID!
  name: String!
  primaryFunction: String
}
```
  </div>
  <div class="flex-1">
  Query 

```gql  
{
  hero(episode: JEDI) {
    name
    ... on Droid { # inline fragment
      primaryFunction
    }
  }
}
```
  </div>
</div>

---

# How does GraphQL work?

- Union types
  - `union SearchResult = Human | Droid | Starship`
- Input Object types
  - field arguments must specify their *input types*

```gql
type ReviewInput {
  stars: Int!
  commentary: String
}

type mutation {
  createReview(episode: Episode, review: ReviewInput!): Review
}
```

---

# How does GraphQL work?

- Ask for only the data you need
- Get many resources in a single request
  - data loaders are used to prevent the n+1 problem

<br> 

```gql
query GetUser {
  user(id: "bb0f18a8-a3bc-4dc8-90b8-cf89fac5b5ad") {
    name
    posts {
      title
    }
    followers(last: 3) {
      name
    }
  }
}
```
