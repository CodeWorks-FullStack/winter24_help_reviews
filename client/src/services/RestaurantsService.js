import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RestaurantsService {
  async getRestaurants() {
    const res = await api.get('api/restaurants')
    logger.log('GETTING RESTAURANTS', res.data)
  }
}

export const restaurantsService = new RestaurantsService()