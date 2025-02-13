import { usePrepareOrderMutation } from '@/gql/mutations/prepare-order.gql';
import { useGetBaristasQuery } from '@/gql/queries/get-baristas.gql';
import { createListCollection, Spinner } from '@chakra-ui/react';
import { useMemo } from 'react';
import {
  SelectContent,
  SelectItem,
  SelectRoot,
  SelectTrigger,
  SelectValueText,
} from './ui/select';

type BaristaSelectProps = {
  orderId: number;
};
export const BaristaSelect = ({ orderId }: BaristaSelectProps) => {
  const { data, loading } = useGetBaristasQuery({
    fetchPolicy: 'cache-first',
  });
  const [prepareOrder] = usePrepareOrderMutation();

  const baristas = useMemo(
    () =>
      createListCollection({
        items: data?.baristas ?? [],
        itemToValue: item => item.id,
        itemToString: item => item.name,
      }),
    [data?.baristas],
  );

  const handleValueChange = (value: string[]) => {
    const baristaId = value.at(0);
    if (!baristaId) {
      return;
    }

    prepareOrder({
      variables: { input: { orderId, baristaId } },
    });
  };

  if (loading) {
    return <Spinner size="xs" />;
  }

  return (
    <SelectRoot
      size="xs"
      width={180}
      collection={baristas}
      onValueChange={({ value }) => handleValueChange(value)}
    >
      <SelectTrigger>
        <SelectValueText placeholder="Assign Barista" />
      </SelectTrigger>
      <SelectContent>
        {baristas.items.map(barista => (
          <SelectItem key={barista.id} item={barista}>
            {barista.name}
          </SelectItem>
        ))}
      </SelectContent>
    </SelectRoot>
  );
};
