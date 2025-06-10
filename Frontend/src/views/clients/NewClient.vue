<script setup>
import { ref } from 'vue'
import * as yup from 'yup'
import { useRouter } from 'vue-router'

import { Form } from '@primevue/forms'
import { yupResolver } from '@primevue/forms/resolvers/yup'

import Toast from 'primevue/toast'
import Button from 'primevue/button'
import Message from 'primevue/message'
import InputText from 'primevue/inputtext'
import { useToast } from 'primevue/usetoast'

import { createClient } from '@/services/clientService'

import { useUIStore } from '@/stores/ui'

const uiStore = useUIStore()
const router = useRouter()
const toast = useToast()

const initialValues = ref({
  name: '',
  email: '',
})

const resolver = ref(
  yupResolver(
    yup.object().shape({
      name: yup.string().required('El nombre es requerido'),
      email: yup.string().email('Debe ser un email válido').required('El email es requerido'),
    }),
  ),
)

const onFormSubmit = async (event) => {
  if (!event.valid) {
    return
  }

  try {
    uiStore.blockUI()

    const client = {
      name: event.values.name,
      email: event.values.email,
    }

    await createClient(client)

    toast.add({ severity: 'success', summary: 'Cliente creado correctamente', life: 3000 })

    event.reset()
  } catch (error) {
    toast.add({ severity: 'error', summary: 'Ocurrió un error al crear cliente', life: 3000 })
  } finally {
    uiStore.unblockUI()
  }
}

const goHome = () => {
  router.push({ name: 'home' })
}
</script>

<template>
  <Toast />
  <div class="grid">
    <div class="col-12 flex justify-content-center">
      <h1 class="mb-2 text-color">Nuevo Cliente</h1>
    </div>

    <div class="col-12 flex justify-content-center">
      <h3 class="mt-0 text-color">Registra un nuevo cliente en el sistema</h3>
    </div>

    <div class="col-12 mt-4 flex justify-content-center">
      <Form
        v-slot="$form"
        :initial-values="initialValues"
        :resolver="resolver"
        @submit="onFormSubmit"
      >
        <div class="grid">
          <div class="col-12">
            <div class="field">
              <label for="name">Nombre</label>
              <InputText
                id="name"
                name="name"
                type="text"
                placeholder="Ingrese el nombre del cliente"
                class="w-full"
              />
              <Message v-if="$form.name?.invalid" severity="error" size="small" variant="simple">
                {{ $form.name.error.message }}
              </Message>
            </div>
          </div>
          <div class="col-12">
            <div class="field">
              <label for="email">Email</label>
              <InputText
                id="email"
                name="email"
                type="text"
                placeholder="cliente@ejemplo.com"
                class="w-full"
              />
              <Message v-if="$form.email?.invalid" severity="error" size="small" variant="simple">
                {{ $form.email.error.message }}
              </Message>
            </div>
          </div>
        </div>
        <div class="grid mt-3">
          <div class="col-12 md:col-6">
            <Button label="Cancelar" severity="secondary" outlined class="w-full" @click="goHome" />
          </div>
          <div class="col-12 md:col-6">
            <Button label="Crear" class="w-full" type="submit" />
          </div>
        </div>
      </Form>
    </div>
  </div>
</template>
