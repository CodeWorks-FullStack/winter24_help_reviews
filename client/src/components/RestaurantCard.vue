<template>
  <router-link :to="{ name: 'Restaurant Details', params: { restaurantId: restaurant.id } }">
    <div class="shadow-lg text-dark">
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
  </router-link>
</template>


<script>
import { Restaurant } from '../models/Restaurant.js'
export default {
  props: {
    restaurant: { type: Restaurant, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
}
</style>