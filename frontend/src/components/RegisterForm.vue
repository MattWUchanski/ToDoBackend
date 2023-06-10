<template>
    <div class="register-container">
      <h3>Zarejestruj się</h3>
      <div id="alert-area">
        {{ alertText }}
      </div>
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label for="name"><i class="fa fa-user" aria-hidden="true"></i></label>
          <input type="text" id="login" v-model="login" required>
        </div>
        
        <div class="form-group">
          <label for="password"><i class="fa fa-key" aria-hidden="true"></i></label>
          <input type="password" id="password" v-model="password" required>
        </div>
        
        <div class="form-group">
          <label for="confirmEmail"><i class="fa fa-key" aria-hidden="true"></i></label>
          <input type="password" id="confirmPassword" v-model="confirmPassword" required>
        </div>
        
        <div class="form-group">
          <label for="email"><i class="fa fa-envelope" aria-hidden="true"></i></label>
          <input type="email" id="email" v-model="email" required>
        </div>
        
        <button type="submit" :class="mode">Zarejestruj się</button>
      </form>
    </div>
  </template>
  
  
  <script> 
function isEmailValid(email) {
  // Regular expression pattern for email validation - not yet used
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  
    return emailPattern.test(email);
}
  import { mapState } from 'vuex';
  export default {
     computed: {
        // użyj mapState, aby pobierać wartość 'mode' z Vuex store
        ...mapState(['mode', 'selectedDate']),
    },
    data() {
      return {
        alertText: '',
        login: '',
        email: '',
        password: '',
        confirmPassword: '',
      };
    },
    methods: {
      submitForm() {
        alert("Rejestracja użytkownika " + this.login);
        // Rejestracja przez API
      },
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
.register-container {
  max-width: 445px;
  min-width: 490px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f5f5f5;
  border: 1px solid #ddd;
  border-radius: 4px;
}
@media screen and (max-width: 500px) {
.register-container {
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

</style>
  
  
