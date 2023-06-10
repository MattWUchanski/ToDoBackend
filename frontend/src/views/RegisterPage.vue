<template>
    <div>
        <RegisterNavbar :mode="mode" />
    </div>
        <div class="container">
        <RegisterForm />
        </div>
</template>

<script>
import RegisterNavbar from '../components/RegisterNavbar.vue';
import RegisterForm from '../components/RegisterForm.vue';

import { mapState } from 'vuex';

export default {
      components: {
        RegisterNavbar,
        RegisterForm,
      },
      computed: {
        // użyj mapState, aby pobierać wartość 'mode' z Vuex store
        ...mapState(['mode', 'selectedDate']),
        
    },
    data() {
      
  },
  methods: {
    
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
  .container {
    display: flex;
    justify-content: center;
    margin-top: 10px;
  }
  
  .active-blue {
    color: #0099FF;
}

.active-green {
    color: #009900;
}


</style>