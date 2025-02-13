import { Box, Heading } from '@chakra-ui/react';
import { NewOrder } from './NewOrder';

export const Header = () => {
  return (
    <Box
      as="header"
      borderBottomWidth={1}
      p={4}
      display="flex"
      justifyContent="space-between"
    >
      <Heading size="3xl">Coffee Shop</Heading>
      <NewOrder />
    </Box>
  );
};
