<script setup>
import { ref } from 'vue'
import { useRouter, RouterView } from 'vue-router'

import Toast from 'primevue/toast'
import Menubar from 'primevue/menubar'

import LoadingOverlay from '@/components/LoadingOverlay.vue'

const router = useRouter()

const menuItems = ref([
  {
    label: 'Inicio',
    icon: 'pi pi-home',
    command: () => router.push({ name: 'home' }),
  },
  {
    label: 'Clientes',
    icon: 'pi pi-user',
    items: [
      {
        label: 'Nuevo Cliente',
        icon: 'pi pi-user-plus',
        command: () => router.push({ name: 'clients-new' }),
      },
    ],
  },
  {
    label: 'Transacciones',
    icon: 'pi pi-folder-open',
    items: [
      {
        label: 'Historial de Movimientos',
        icon: 'pi pi-history',
        command: () => router.push({ name: 'transactions-history' }),
      },
    ],
  },
])
</script>

<template>
  <LoadingOverlay />

  <div class="flex flex-column h-screen">
    <Menubar :model="menuItems" />

    <div class="bg-white mt-2 p-3 border-round flex-grow-1">
      <RouterView />
    </div>

    <Toast />
  </div>
</template>

<style>
.h-screen {
  min-height: 100vh;
}
</style>
