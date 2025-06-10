const backendApi = import.meta.env.VITE_BACKEND_API

export async function createClient(client) {
  try {
    const response = await fetch(backendApi + '/api/clients', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(client),
    })

    if (!response.ok) {
      throw new Error('No se pudo crear el cliente')
    }

    const data = await response.json()
    return data
  } catch (error) {
    console.error('Error al crear cliente:', error)
    throw error
  }
}

export async function getClients() {
  try {
    const url = new URL(backendApi + '/api/clients')

    const response = await fetch(url.toString(), {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })

    if (!response.ok) {
      throw new Error(`No se pudieron obtener los clientes`)
    }

    const data = await response.json()
    return data
  } catch (error) {
    console.error('Error al obtener los clientes:', error)
    throw error
  }
}
