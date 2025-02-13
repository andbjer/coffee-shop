import { defineShikiSetup } from "@slidev/types";

export default defineShikiSetup(() => {
  return {
    themes: {
      dark: "nord",
      light: "nord",
    },
    langs: ["gql"],
  };
});
