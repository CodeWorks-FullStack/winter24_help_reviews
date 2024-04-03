<template>
  <h1>RESTAURNAT PAGE</h1>
</template>


<script>
import Pop from '../utils/Pop.js'
import { restaurantsService } from '../services/RestaurantsService.js'
import { watch } from 'vue';
import { useRoute } from 'vue-router';
export default {
  setup() {
    const route = useRoute()


    async function getRestaurantById(restaurantId) {
      try {
        await restaurantsService.getRestaurantById(restaurantId)
      }
      catch (error) {
        Pop.error(error);
      }
    }

    watch(() => route.params.restaurantId, () => {
      getRestaurantById(route.params.restaurantId)
    }, { immediate: true })

    return {}
  }
}
</script>


<style lang="scss" scoped></style>