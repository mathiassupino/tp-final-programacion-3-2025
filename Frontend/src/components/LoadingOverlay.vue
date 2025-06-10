<script setup>
import ProgressSpinner from 'primevue/progressspinner'

import { useUIStore } from '@/stores/ui'

const uiStore = useUIStore()
</script>

<template>
  <div v-if="uiStore.isLoading" class="spinner-overlay">
    <ProgressSpinner
      style="width: 50px; height: 50px"
      strokeWidth="3"
      fill="transparent"
      animationDuration="1s"
      aria-label="Custom ProgressSpinner"
    />
  </div>
</template>

<style scoped>
.spinner-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(255, 255, 255, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 9999;
}
</style>
