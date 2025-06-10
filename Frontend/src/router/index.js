import { createRouter, createWebHistory } from 'vue-router'

const Home = () => import('../views/Home.vue')
const PageNotFound = () => import('../views/PageNotFound.vue')
const NewClient = () => import('../views/clients/NewClient.vue')
const TransactionHistory = () => import('../views/transactions/TransactionHistory.vue')

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '',
      name: 'home',
      component: Home,
    },
    {
      path: '/clients/new',
      name: 'clients-new',
      component: NewClient,
    },
    {
      path: '/transactions/history',
      name: 'transactions-history',
      component: TransactionHistory,
    },
    { path: '/:catchAll(.*)', component: PageNotFound },
  ],
})

export default router
