<script setup>
import { ref, onMounted } from 'vue'

import Tag from 'primevue/tag'
import Panel from 'primevue/panel'
import Select from 'primevue/select'
import Button from 'primevue/button'
import Column from 'primevue/column'
import DataTable from 'primevue/datatable'

import { getClients } from '@/services/clientService'
import { getTransactions } from '@/services/transactionService'

import { useUIStore } from '@/stores/ui'

const uiStore = useUIStore()

const clients = ref([])
const selectedClient = ref(null)
const transactions = ref([])
const showTransactionsSection = ref(false)

const onClientSelect = async () => {
  if (selectedClient.value) {
    await getTransactionsList(selectedClient.value.id)
    showTransactionsSection.value = true
  }
}

const getClientList = async () => {
  clients.value = await getClients()
}

const getTransactionsList = async (clientId) => {
  try {
    uiStore.blockUI()
    transactions.value = await getTransactions(clientId)
    showTransactionsSection.value = true
  } finally {
    uiStore.unblockUI()
  }
}

const getActionSeverity = (data) => {
  return data.action === 0 ? 'success' : 'danger'
}

const getActionText = (data) => {
  return data.action === 0 ? 'Compra' : 'Venta'
}

onMounted(async () => {
  uiStore.blockUI()
  await getClientList()
  uiStore.unblockUI()
})
</script>

<template>
  <div class="grid">
    <div class="col-12">
      <h1 class="mt-0 mb-1 text-color">Historial de movimientos</h1>
    </div>

    <div class="col-12">
      <Panel header="Seleccionar Cliente">
        <p class="mt-0">Elige un cliente para ver su historial de transacciones</p>
        <div v-if="clients.length === 0" class="flex justify-content-center">
          <p>No hay clientes cargados</p>
        </div>
        <div v-else>
          <Select
            v-model="selectedClient"
            :options="clients"
            optionLabel="name"
            placeholder="Selecciona un cliente"
          />
          <Button
            class="ml-2"
            severity="secondary"
            label="Buscar"
            :disabled="!selectedClient"
            @click="onClientSelect"
          />
        </div>
      </Panel>
    </div>

    <div v-if="showTransactionsSection" class="col-12">
      <Panel header="Transacciones">
        <p class="mt-0">Historial completo de compras y ventas</p>
        <DataTable
          v-if="transactions.length > 0"
          :value="transactions"
          tableStyle="min-width: 50rem"
        >
          <Column header="Acción" sortable>
            <template #body="slotProps">
              <Tag
                :value="getActionText(slotProps.data)"
                :severity="getActionSeverity(slotProps.data)"
              />
            </template>
          </Column>
          <Column field="cryptoCode" header="Criptomoneda" sortable></Column>
          <Column field="cryptoAmount" header="Cantidad" sortable></Column>
          <Column field="money" header="Monto" sortable>
            <template #body="slotProps">
              {{ `$${slotProps.data.money.toLocaleString('es-AR')}` }}
            </template>
          </Column>
          <Column field="datetime" header="Fecha y Hora" sortable>
            <template #body="slotProps">
              {{ new Date(slotProps.data.datetime).toLocaleString() }}
            </template>
          </Column>
        </DataTable>
        <div v-else class="flex justify-content-center">
          <p>No hay transacciones para este cliente</p>
        </div>
      </Panel>
    </div>
  </div>
</template>
