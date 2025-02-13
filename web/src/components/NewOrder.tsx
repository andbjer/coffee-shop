import { useAddOrderMutation } from '@/gql/mutations/add-order.gql';
import { useGetCustomersQuery } from '@/gql/queries/get-customers.gql';
import { useGetDrinksQuery } from '@/gql/queries/get-drinks.gql';
import { useGetOrdersLazyQuery } from '@/gql/queries/get-orders.gql';
import { Button, createListCollection, Spinner, Stack } from '@chakra-ui/react';
import { RefObject, useMemo, useRef, useState } from 'react';
import {
  DialogActionTrigger,
  DialogBody,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogRoot,
  DialogTitle,
  DialogTrigger,
} from './ui/dialog';
import {
  SelectContent,
  SelectItem,
  SelectLabel,
  SelectRoot,
  SelectTrigger,
  SelectValueText,
} from './ui/select';

export const NewOrder = () => {
  const [dialogOpen, setDialogOpen] = useState(false);
  const [customer, setCustomer] = useState<string[]>([]);
  const [drink, setDrink] = useState<string[]>([]);
  const contentRef = useRef<HTMLDivElement>(null);

  const { data: customerData, loading: customersLoading } =
    useGetCustomersQuery({
      fetchPolicy: 'cache-first',
    });

  const customers = useMemo(
    () =>
      createListCollection({
        items: customerData?.customers ?? [],
        itemToValue: item => item.id,
        itemToString: item => item.name,
      }),
    [customerData?.customers],
  );

  const { data: drinkData, loading: drinkLoading } = useGetDrinksQuery({
    fetchPolicy: 'cache-first',
  });

  const drinks = useMemo(
    () =>
      createListCollection({
        items: drinkData?.drinks ?? [],
        itemToValue: item => item.id,
        itemToString: item => item.name,
      }),
    [drinkData?.drinks],
  );

  const [addOrder, { loading: saving }] = useAddOrderMutation();
  const [getOrders] = useGetOrdersLazyQuery();

  const save = async () => {
    const customerId = customer.at(0);
    const drinkId = drink.at(0);

    if (!customerId || !drinkId) {
      return;
    }

    await addOrder({
      variables: {
        input: {
          customerId,
          drinkId,
        },
      },
    });
    getOrders();
    setDialogOpen(false);
  };

  const loading = customersLoading || drinkLoading;
  const valid = customer.length === 1 && drink.length === 1;

  // TODO: add description and price to drink
  return (
    <DialogRoot open={dialogOpen} onOpenChange={e => setDialogOpen(e.open)}>
      <DialogTrigger asChild>
        <Button variant="outline" size="sm">
          New Order
        </Button>
      </DialogTrigger>
      <DialogContent ref={contentRef}>
        <DialogHeader>
          <DialogTitle>New Order</DialogTitle>
        </DialogHeader>
        <DialogBody>
          {loading ? (
            <Spinner />
          ) : (
            <Stack>
              <SelectRoot
                collection={customers}
                value={customer}
                onValueChange={({ value }) => setCustomer(value)}
              >
                <SelectLabel>Select customer</SelectLabel>
                <SelectTrigger>
                  <SelectValueText placeholder="Select customer" />
                </SelectTrigger>
                <SelectContent
                  portalRef={contentRef as RefObject<HTMLDivElement>}
                >
                  {customers.items.map(customer => (
                    <SelectItem key={customer.id} item={customer}>
                      {customer.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </SelectRoot>
              <SelectRoot
                collection={drinks}
                value={drink}
                onValueChange={({ value }) => setDrink(value)}
              >
                <SelectLabel>Select drink</SelectLabel>
                <SelectTrigger>
                  <SelectValueText placeholder="Select drink" />
                </SelectTrigger>
                <SelectContent
                  portalRef={contentRef as RefObject<HTMLDivElement>}
                >
                  {drinks.items.map(drink => (
                    <SelectItem key={drink.id} item={drink}>
                      {drink.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </SelectRoot>
            </Stack>
          )}
        </DialogBody>
        <DialogFooter>
          <DialogActionTrigger asChild>
            <Button variant="outline">Cancel</Button>
          </DialogActionTrigger>
          <Button
            variant="outline"
            disabled={!valid}
            loading={saving}
            loadingText="Saving..."
            spinnerPlacement="end"
            onClick={save}
          >
            Add order
          </Button>
        </DialogFooter>
      </DialogContent>
    </DialogRoot>
  );
};
