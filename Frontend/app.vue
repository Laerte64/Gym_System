<template>
  <div class="background-container">
    <img src="/academia1.jpeg" alt="background image" class="background-image" />

    <div class="overlay"></div>

    <div class="overlay flex justify-content-center align-items-center">
      <div class="card w-4 p-4">
        <h2 class="text-center">Login</h2>
        <div class="field mt-4">
          <label for="username">Usuário</label>
          <InputText id="username" v-model="username" class="w-full" placeholder="Digite seu usuário" />
        </div>
        <div class="field mt-4">
          <label for="password">Senha</label>
          <InputText id="password" v-model="password" type="password" class="w-full" placeholder="Digite sua senha" />
        </div>
        <div class="flex justify-content-center mt-4">
          <Button label="Entrar" class="custom-button w-full" @click="login" />
        </div>
        <div v-if="errorMessage" class="error-message text-center mt-2">
          {{ errorMessage }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';
import { InputText } from 'primevue/inputtext';
import { Button } from 'primevue/button';
import { useRouter } from 'vue-router';

export default {
  components: {
    InputText,
    Button
  },
  setup() {
    const username = ref('');
    const password = ref('');
    const errorMessage = ref('');
    const router = useRouter();

    const login = () => {
      const validUsername = 'admin';
      const validPassword = '123';

      if (username.value === validUsername && password.value === validPassword) {
        errorMessage.value = '';
        router.push('/training-days');
      } else {
        errorMessage.value = 'Usuário ou senha inválidos';
      }
    };

    return {
      username,
      password,
      login,
      errorMessage
    };
  }
};
</script>

<style scoped>
html, body {
  margin: 0;
  padding: 0;
  height: 100%;
  overflow-x: hidden;
}

.background-container {
  position: relative;
  width: 100vw;
  height: 100vh;
  overflow-y: hidden;
}

.background-image {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  object-fit: cover;
  filter: brightness(50%);
  transform: scale(1.1);
}

.overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.4);
  display: flex;
  justify-content: center;
  align-items: center;
}

.card {
  display: flex;
  flex-direction: column;
  min-width: 300px;
  background-color: rgba(0, 0, 0, 0.6);
  border-radius: 8px;
  padding: 20px;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.5);
}

.text-center {
  text-align: center;
}

.custom-button {
  background-color: #b22222;
  color: white;
  border: none;
}

.custom-button:hover {
  background-color: darkred;
}

.error-message {
  color: red;
  font-weight: bold;
}
</style>
