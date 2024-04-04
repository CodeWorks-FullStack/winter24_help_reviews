<template>
  <div v-if="restaurant" class="container">
    <section class="row my-3">
      <div class="col-12 shadow-lg p-0">
        <div class="d-flex justify-content-between">
          <h1 class="text-success fs-3 m-1">{{ restaurant.name }}</h1>
          <p v-if="restaurant.isShutdown" class="bg-danger text-light px-3 mb-0">
            <i class="mdi mdi-close-circle"></i>
            CURRENTLY SHUTDOWN
          </p>
        </div>
        <img :src="restaurant.imgUrl" :alt="restaurant.name" class="restaurant-img">
        <div class="p-2 mb-4">
          <p>{{ restaurant.description }}</p>
        </div>
        <div class="p-2 d-flex justify-content-between">
          <div class="d-flex">
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

          <div v-if="restaurant.creatorId == account.id">
            <button class="btn btn-success"><i class="mdi mdi-door-open"></i> Re-Open</button>
            <button @click="destroyRestaurant(restaurant.id)" class="btn btn-danger ms-3">
              <i class="mdi mdi-delete-forever"></i>
              Delete
            </button>
          </div>
        </div>
      </div>
    </section>

    <section class="row justify-content-center">
      <div class="col-md-10">
        <h2 class="fs-4">Reports for <span class="text-success">{{ restaurant.name }}</span></h2>
      </div>
      <div v-for="report in reports" :key="report.id" class="col-md-10 mb-3">
        <div class="shadow-lg p-4">
          <div class="d-flex justify-content-between">
            <div></div>

            <h3 class="fs-5 text-success">"{{ report.title }}"</h3>

            <div class="d-flex">
              <div>
                <p>{{ report.creator.name }}</p>
                <p>{{ report.createdAt.toLocaleDateString() }}</p>
              </div>
              <img :src="report.creator.picture" :alt="report.creator.name">
            </div>

          </div>
          <p v-if="report.body">{{ report.body }}</p>
        </div>
      </div>
    </section>
  </div>
  <div v-else class="container">
    <div class="row">
      <div class="col-12">
        Loading...
      </div>
    </div>
  </div>
</template>


<script>
import Pop from '../utils/Pop.js'
import { restaurantsService } from '../services/RestaurantsService.js'
import { computed, watch } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js'
import { reportsService } from '../services/ReportsService.js'
export default {
  setup() {
    const route = useRoute()
    const router = useRouter()


    async function getRestaurantById(restaurantId) {
      try {
        await restaurantsService.getRestaurantById(restaurantId)
      }
      catch (error) {
        Pop.error(error);
      }
    }

    async function getReportsByRestaurantId(restaurantId) {
      try {
        await reportsService.getReportsByRestaurantId(restaurantId)
      }
      catch (error) {
        Pop.error(error);
      }
    }

    watch(() => route.params.restaurantId, () => {
      getRestaurantById(route.params.restaurantId)
      getReportsByRestaurantId(route.params.restaurantId)
    }, { immediate: true })

    return {
      restaurant: computed(() => AppState.activeRestaurant),
      account: computed(() => AppState.account),
      reports: computed(() => AppState.reports),

      async destroyRestaurant(restaurantId) {
        try {
          const yes = await Pop.confirm()

          if (!yes) return

          await restaurantsService.destroyRestaurant(restaurantId)

          router.push({ name: 'Home' })
        }
        catch (error) {
          Pop.error(error);
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.restaurant-img {
  width: 100%;
  height: 48vh;
  object-fit: cover;
}
</style>