// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },
  modules: [
    'nuxt-primevue'
],
  primevue: {
    /* Options */
},
css: ['primevue/resources/themes/aura-dark-lime/theme.css', 'primeflex/primeflex.css', 'primeicons/primeicons.css']
})
