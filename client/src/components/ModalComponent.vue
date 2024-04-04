<template>
  <div class="modal fade" id="reportModal" tabindex="-1" aria-labelledby="reportModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content ">
        <div class="modal-header">
          <h1 class="modal-title fs-5 text-success" id="reportModalLabel">What do you say?</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="mb-3">
              <label for="title" class="form-label">Report Title</label>
              <input type="text" class="form-control" id="title" placeholder="Report Title..." maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="pictureOfDisgust" class="form-label">Report Picture Of Disgust</label>
              <input type="url" class="form-control" id="pictureOfDisgust" placeholder="Report Picture Of Disgust..."
                maxlength="255" required>
            </div>
            <div class="mb-3">
              <label for="body" class="form-label">Report Body</label>
              <textarea class="form-control" id="body" rows="3" maxlength="1000"></textarea>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped></style>