import { AppState } from "../AppState.js"
import { Restaurant } from "../models/Restaurant.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RestaurantsService {
  async destroyRestaurant(restaurantId) {
    const res = await api.delete(`api/restaurants/${restaurantId}`)
    logger.log('DESTROYED RESTAURANT', res.data)
  }
  async getRestaurantById(restaurantId) {
    const res = await api.get(`api/restaurants/${restaurantId}`)
    logger.log('GOT RESTAURANT', res.data)
    AppState.activeRestaurant = new Restaurant(res.data)
  }
  async getRestaurants() {
    const res = await api.get('api/restaurants')
    logger.log('GETTING RESTAURANTS', res.data)
    AppState.restaurants = res.data.map(pojo => new Restaurant(pojo))
  }
}

export const restaurantsService = new RestaurantsService()