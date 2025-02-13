import {
  ApolloClient,
  DefaultOptions,
  HttpLink,
  InMemoryCache,
  split,
} from '@apollo/client';
import { GraphQLWsLink } from '@apollo/client/link/subscriptions';
import { getMainDefinition } from '@apollo/client/utilities';
import { createClient } from 'graphql-ws';

const defaultOptions: DefaultOptions = {
  watchQuery: {
    fetchPolicy: 'cache-and-network',
    nextFetchPolicy: 'cache-first',
    errorPolicy: 'none',
  },
};

const httpLink = new HttpLink({
  uri: 'graphql/',
});
const wsLink = new GraphQLWsLink(
  createClient({
    url: 'ws://localhost:5266/graphql',
    lazy: true,
  }),
);
const splitLink = split(
  ({ query }) => {
    const definition = getMainDefinition(query);
    return (
      definition.kind === 'OperationDefinition' &&
      definition.operation === 'subscription'
    );
  },
  wsLink,
  httpLink,
);

export const client = new ApolloClient({
  uri: 'graphql/',
  link: splitLink,
  cache: new InMemoryCache(),
  devtools: {
    enabled: true,
  },
  defaultOptions,
});
