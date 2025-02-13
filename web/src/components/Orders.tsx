import { OrderStatus } from '@/gql/api';
import { useGetOrdersSuspenseQuery } from '@/gql/queries/get-orders.gql';
import { useOrderUpdatedSubscription } from '@/gql/subscriptions/order-updated.gql';
import { Grid, GridItem, Tabs } from '@chakra-ui/react';
import { useEffect, useMemo } from 'react';
import { Order } from './Order';
import { toaster } from './ui/toaster';

export const Orders = () => {
  const { data } = useGetOrdersSuspenseQuery();
  const { data: orderUpdatedData } = useOrderUpdatedSubscription();

  useEffect(() => {
    const order = orderUpdatedData?.orderUpdated;
    if (!order || order.status === OrderStatus.Ordered) {
      return;
    }

    toaster.create({
      title:
        order.status === OrderStatus.Pending
          ? `Order #${order.id} is being prepared...`
          : `Order #${order.id} is ready!`,
      type: order.status === OrderStatus.Pending ? 'info' : 'success',
    });
  }, [orderUpdatedData?.orderUpdated]);

  const newOrders = useMemo(
    () => data?.orders.filter(x => x.status === OrderStatus.Ordered) ?? [],
    [data?.orders],
  );
  const ordersPreparing = useMemo(
    () => data?.orders.filter(x => x.status === OrderStatus.Pending) ?? [],
    [data?.orders],
  );
  const completedOrders = useMemo(
    () => data?.orders.filter(x => x.status === OrderStatus.Completed) ?? [],
    [data?.orders],
  );

  return (
    <Tabs.Root defaultValue="created" variant="line">
      <Tabs.List>
        <Tabs.Trigger
          style={{ backgroundColor: 'transparent' }}
          value="created"
        >
          New
        </Tabs.Trigger>
        <Tabs.Trigger
          style={{ backgroundColor: 'transparent' }}
          value="preparing"
        >
          Preparing
        </Tabs.Trigger>
        <Tabs.Trigger
          style={{ backgroundColor: 'transparent' }}
          value="completed"
        >
          Completed
        </Tabs.Trigger>
      </Tabs.List>
      <Tabs.Content value="created">
        <Grid templateColumns="repeat(3, 1fr)" gap={6}>
          {newOrders.length === 0 && (
            <GridItem colSpan={3} textAlign="center">
              No new orders
            </GridItem>
          )}
          {newOrders.map(x => (
            <Order key={x.id} order={x} />
          ))}
        </Grid>
      </Tabs.Content>
      <Tabs.Content value="preparing">
        <Grid templateColumns="repeat(3, 1fr)" gap={6}>
          {ordersPreparing.length === 0 && (
            <GridItem colSpan={3} textAlign="center">
              No orders are being prepared
            </GridItem>
          )}
          {ordersPreparing.map(x => (
            <Order key={x.id} order={x} />
          ))}
        </Grid>
      </Tabs.Content>
      <Tabs.Content value="completed">
        <Grid templateColumns="repeat(3, 1fr)" gap={6}>
          {completedOrders.length === 0 && (
            <GridItem colSpan={3} textAlign="center">
              No completed orders
            </GridItem>
          )}
          {completedOrders.map(x => (
            <Order key={x.id} order={x} />
          ))}
        </Grid>
      </Tabs.Content>
    </Tabs.Root>
  );
};
