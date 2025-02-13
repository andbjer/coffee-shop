import react from '@vitejs/plugin-react-swc';
import { defineConfig } from 'vite';
import tsconfigPaths from 'vite-tsconfig-paths';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), tsconfigPaths()],
  server: {
    host: 'localhost',
    port: 3000,
    open: 'http://localhost:3000',
    proxy: {
      '/graphql': 'http://localhost:5266',
    },
  },
});
