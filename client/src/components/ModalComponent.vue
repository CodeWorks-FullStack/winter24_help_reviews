<template>
  <div class="modal fade" id="reportModal" tabindex="-1" aria-labelledby="reportModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content ">
        <div class="modal-header">
          <h1 class="modal-title fs-5 text-success" id="reportModalLabel">What do you say?</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createReport()">
            <select v-model="editableReportData.restaurantId" class="form-select" aria-label="Select a Restaurant"
              required>
              <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">
                {{ restaurant.name }}
              </option>
            </select>
            <div class="mb-3">
              <label for="title" class="form-label">Report Title</label>
              <input v-model="editableReportData.title" type="text" class="form-control" id="title"
                placeholder="Report Title..." maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="pictureOfDisgust" class="form-label">Report Picture Of Disgust</label>
              <input v-model="editableReportData.pictureOfDisgust" type="url" class="form-control" id="pictureOfDisgust"
                placeholder="Report Picture Of Disgust..." maxlength="255">
            </div>
            <div class="mb-3">
              <label for="body" class="form-label">Report Body</label>
              <textarea v-model="editableReportData.body" class="form-control" id="body" rows="3"
                maxlength="1000"></textarea>
            </div>


            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
              <button type="submit" class="btn btn-primary">Submit Report</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref } from 'vue'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'
import { reportsService } from '../services/ReportsService.js'
export default {
  setup() {
    const editableReportData = ref({})
    return {
      editableReportData,
      restaurants: computed(() => AppState.restaurants),
      async createReport() {
        try {
          await reportsService.createReport(editableReportData.value)
          editableReportData.value = {}
        }
        catch (error) {
          Pop.error(error);
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>