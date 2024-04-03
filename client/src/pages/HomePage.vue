<template>
  <div>Chill out</div>
</template>

<script>
import { onMounted } from 'vue';
import { restaurantsService } from '../services/RestaurantsService.js';
import Pop from '../utils/Pop.js';

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

    }
  }
}
</script>

<style scoped lang="scss"></style>
