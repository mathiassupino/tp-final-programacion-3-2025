const backendApi = import.meta.env.VITE_BACKEND_API

export async function getTransactions(clientId) {
  try {
    const url = new URL(backendApi + '/api/transactions')
    url.searchParams.append('clientId', clientId)

    const response = await fetch(url.toString(), {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })

    if (!response.ok) {
      throw new Error(`No se pudieron obtener las transacciones`)
    }

    const data = await response.json()
    return data
  } catch (error) {
    console.error('Error al obtener las transacciones:', error)
    throw error
  }
}
