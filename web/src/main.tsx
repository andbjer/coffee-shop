import { ApolloProvider } from '@apollo/client';
import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import App from './App.tsx';
import { Provider } from './components/ui/provider.tsx';
import { client } from './gql/client.ts';
import './index.css';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider>
      <ApolloProvider client={client}>
        <App />
      </ApolloProvider>
    </Provider>
  </StrictMode>,
);
