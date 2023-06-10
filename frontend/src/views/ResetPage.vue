<template>
    <div>
        <ResetNavbar :mode="mode" />
    </div>
        <div class="container">
        <ResetForm />
        </div>
</template>

<script>
import ResetNavbar from '../components/ResetNavbar.vue';
import ResetForm from '../components/ResetForm.vue';

import { mapState } from 'vuex';

export default {
      components: {
        ResetNavbar,
        ResetForm,
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
.button {
  display: block;
  width: 200px;
  padding: 10px 20px;
  background-color: #4CAF50;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  text-decoration: none;
  margin-bottom: 10px;
}

.router-links {
  text-align: center;
}

</style>