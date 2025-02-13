import { OrderFragment } from '@/gql/queries/get-orders.gql';
import { Card, Flex, Heading, Text } from '@chakra-ui/react';
import { BaristaSelect } from './BaristaSelect';

type OrderProps = {
  order: OrderFragment;
};
export const Order = ({ order }: OrderProps) => {
  return (
    <Card.Root size="sm">
      <Card.Header>
        <Heading size="lg" fontWeight="semibold">
          #{order.id} - {order.customer?.name}
        </Heading>
      </Card.Header>
      <Card.Body>
        <Flex gap={2}>
          <Text fontWeight="semibold">Drink:</Text>
          <Text fontWeight="light">{order.drink?.name}</Text>
        </Flex>
        <Flex gap={2} alignItems="center">
          <Text fontWeight="semibold">Barista:</Text>
          {order.barista ? (
            <Text fontWeight="light">{order.barista.name}</Text>
          ) : (
            <BaristaSelect orderId={order.id} />
          )}
        </Flex>
      </Card.Body>
    </Card.Root>
  );
};
