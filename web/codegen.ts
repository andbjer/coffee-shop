import type { CodegenConfig } from '@graphql-codegen/cli';

const config: CodegenConfig = {
  overwrite: true,
  schema: 'http://localhost:5266/graphql',
  documents: 'src/**/*.graphql',
  generates: {
    'src/gql/api.ts': {
      plugins: ['typescript'],
      config: {
        strictScalars: true,
        scalars: {
          DateTime: 'string | Date',
          TimeSpan: 'string | Date',
          UUID: 'string',
        },
      },
    },
    './schema.graphql': {
      plugins: ['schema-ast'],
      config: {
        includeDirectives: true,
      },
    },
    'src/': {
      preset: 'near-operation-file',
      presetConfig: {
        extension: '.gql.ts',
        baseTypesPath: 'gql/api.ts',
      },
      plugins: ['typescript-operations', 'typescript-react-apollo'],
      config: {
        strictScalars: true,
        scalars: {
          DateTime: 'string | Date',
          TimeSpan: 'string | Date',
          UUID: 'string',
        },
      },
    },
  },
};

export default config;
