<template>
  <div>
    <LoginNavbar :mode="mode" />
  </div>
  <div class="container">
    <LoginForm />
  </div>
</template>

<script>
import LoginNavbar from '../components/LoginNavbar.vue';
import LoginForm from '../components/LoginForm.vue';
import { mapState } from 'vuex';

export default {
  components: {
    LoginNavbar,
    LoginForm,
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

/* .container {
  display: flex;
  justify-content: center;
  margin-top: 10px;
} */

.active-blue {
  color: #0099FF;
}

.active-green {
  color: #009900;
}

small {
  text-align: right;
  color: grey;
}
</style>