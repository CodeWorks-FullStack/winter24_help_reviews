<template>
  <div class="container">
    <section class="row">
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-md-4">
        <RestaurantCard :restaurant="restaurant" />
      </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getRestaurants() {
      try {
        await restaurantsService.getRestaurants()
      }
      catch (error) {
        Pop.error(error);
      }
    }

    onMounted(getRestaurants)

    return {
      restaurants: computed(() => AppState.restaurants)
    }
  }
}
</script>

<style scoped lang="scss"></style>
