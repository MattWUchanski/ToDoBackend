<template>
    <div>
      <div class="reset-container">
        <h3>Resetowanie hasła</h3>
        <form @submit.prevent="submitForm">
          <div class="form-group">
            <label for="email"><i class="fa fa-envelope" aria-hidden="true"></i></label>
            <input type="email" id="email" v-model="email" required placeholder="email@example.com">
          </div>
          <button type="submit" :class="mode">Zresetuj hasło</button>
          <small>
            Powyżej podaj adres e-mail, przypisany do konta w naszej aplikacji, na który możemy wysłać link do zmiany hasła.
          </small>
        </form>
      </div>
      <div class="router-links">
        <router-link to="/" class="button" :class="mode">
          <span class="button-text">Zaloguj się</span>
          <i class="fa fa-user" aria-hidden="true"></i>
        </router-link>
        <router-link to="/register" class="button" :class="mode">
          <span class="button-text">Utwórz konto</span>
          <i class="fa fa-plus-circle" aria-hidden="true"></i>
        </router-link>
      </div>
    </div>
  </template>
  
  
  <script> 
  import { mapState } from 'vuex';
  export default {
     computed: {
        // użyj mapState, aby pobierać wartość 'mode' z Vuex store
        ...mapState(['mode', 'selectedDate']),
    },
    data() {
      return {
        email: '',
      };
    },
    methods: {
      submitForm() {
        alert("Rejestracja użytkownika " + this.login);
        // Rejestracja przez API
      }
    },
  };
  </script>
<style scoped>
.green {
    background-color: #009900;
  }
  .blue {
    background-color: #0099FF;
  }
.reset-container {
  max-width: 445px;
  min-width: 490px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f5f5f5;
  border: 1px solid #ddd;
  border-radius: 4px;
}
@media screen and (max-width: 500px) {
.reset-container {
    min-width: 0px;
    width: 100%;
  }
}
form {
  display: flex;
  flex-direction: column;
}

.form-group {
  display: flex;
  align-items: center;
  margin-bottom: 10px;
}

label {
  margin-right: 10px;
  width: 50px;
}
i{
  font-size: 2rem;
}
input {
  flex: 1;
  padding: 8px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

button {
  padding: 10px 20px;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
.button {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 200px;
  padding: 10px 20px;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  text-decoration: none;
  margin: 0 auto;
  margin-bottom: 10px;
}

.button-text {
  margin-right: 5px;
}

.fa {
  margin-left: 5px;
}

.router-links {
  text-align: center;
  margin-top: 15px;
}
small{
    margin-top: 15px;
}

</style>
  
  
