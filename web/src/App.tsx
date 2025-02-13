import { Box, Spinner } from '@chakra-ui/react';
import { Suspense } from 'react';
import { Header } from './components/Header';
import { Orders } from './components/Orders';
import { Toaster } from './components/ui/toaster';

function App() {
  return (
    <>
      <Header />
      <Box as="main" p={4}>
        <Suspense fallback={<Spinner />}>
          <Orders />
        </Suspense>
      </Box>
      <Toaster />
    </>
  );
}

export default App;
