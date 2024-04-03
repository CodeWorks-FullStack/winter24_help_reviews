<template>
  <div class="container">
    <section class="row">
      <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-md-4">
        <div>
          <img :src="restaurant.imgUrl" :alt="restaurant.name" class="img-fluid">
          <div class="p-2">
            <p class="text-success">
              <b>{{ restaurant.name }}</b>
            </p>
            <p>{{ restaurant.description }}</p>
            <div class="d-flex justify-content-between align-items-center">
              <p>
                <i class="mdi mdi-account-multiple me-1 text-success fs-3"></i>
                <b>{{ restaurant.visits }}</b>
                <span> recent visits</span>
              </p>
              <p>
                <i class="mdi mdi-file-document-multiple me-1 text-success fs-3"></i>
                <b>0</b>
                <span> reports</span>
              </p>
            </div>
          </div>
        </div>
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
