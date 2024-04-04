<template>
  <div class="shadow-lg p-4">
    <div class="d-flex justify-content-between">
      <div></div>

      <h3 class="fs-5 text-success">"{{ report.title }}"</h3>

      <div class="d-flex align-items-center">
        <div>
          <p class="mb-0">{{ report.creator.name }}</p>
          <p class="mb-0">{{ report.createdAt.toLocaleDateString() }}</p>
        </div>
        <img :src="report.creator.picture" :alt="report.creator.name" class="creator-picture ms-2">
      </div>

    </div>
    <p v-if="report.body">{{ report.body }}</p>
  </div>
</template>


<script>
import { Report } from '../models/Report.js'
export default {
  props: {
    report: { type: Report, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.creator-picture {
  height: 10vh;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}
</style>