import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  // @ts-ignore
  account: {},

  /** @type {import('./models/Restaurant.js').Restaurant[]} */
  restaurants: [],

  /** @type {import('./models/Restaurant.js').Restaurant}*/
  activeRestaurant: null,

  /** @type {import('./models/Report.js').Report[]} */
  reports: []
})
