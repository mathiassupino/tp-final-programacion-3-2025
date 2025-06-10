import { createApp } from 'vue'
import { createPinia } from 'pinia'

import Aura from '@primeuix/themes/aura'
import { definePreset } from '@primeuix/themes'

import Tooltip from 'primevue/tooltip'
import PrimeVue from 'primevue/config'
import ToastService from 'primevue/toastservice'

import App from './App.vue'
import router from './router'

import './style.css'

const pinia = createPinia()
const app = createApp(App)

const customAura = definePreset(Aura, {
  semantic: {
    primary: {
      50: '{blue.50}',
      100: '{blue.100}',
      200: '{blue.200}',
      300: '{blue.300}',
      400: '{blue.400}',
      500: '{blue.500}',
      600: '{blue.600}',
      700: '{blue.700}',
      800: '{blue.800}',
      900: '{blue.900}',
      950: '{blue.950}',
    },
  },
})

app
  .use(PrimeVue, {
    theme: {
      preset: customAura,
      options: {
        darkModeSelector: '.p-dark',
      },
    },
  })
  .use(router)
  .use(pinia)
  .use(ToastService)
  .directive('tooltip', Tooltip)
  .mount('#app')
