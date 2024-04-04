<template>
  <div class="offcanvas offcanvas-start" tabindex="-1" id="accountOffcanvas" aria-labelledby="accountOffcanvasLabel">
    <div class="offcanvas-header">
      <h5 class="offcanvas-title" id="accountOffcanvasLabel">Report Menu</h5>
      <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
    </div>
    <div class="offcanvas-body">
      <div class="container-fluid">
        <section class="row">
          <div class="col-12">
            <div class="bg-success text-center text-light">
              <p class="fs-1">HELP</p>
              <i class="mdi mdi-rodent display-1"></i>
            </div>
            <p class="text-center text-success fs-3"><b>food reports</b></p>
            <button @click="closeOffcanvas()" class="btn btn-success w-100 fs-3" data-bs-toggle="modal"
              data-bs-target="#reportModal">
              REPORT!
            </button>
          </div>
        </section>
      </div>
    </div>
  </div>
</template>


<script>
import { Offcanvas } from 'bootstrap';

export default {
  setup() {
    return {
      closeOffcanvas() {
        Offcanvas.getOrCreateInstance('#accountOffcanvas').hide()
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>