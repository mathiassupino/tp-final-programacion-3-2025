import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useUIStore = defineStore('ui', () => {
  const isLoading = ref(false)

  const blockUI = () => {
    isLoading.value = true
  }

  const unblockUI = () => {
    isLoading.value = false
  }

  return {
    isLoading,
    blockUI,
    unblockUI,
  }
})
