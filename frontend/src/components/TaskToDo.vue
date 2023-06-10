<template>
  <div class="container1">
    <div class="tick" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">
      <input type="checkbox" :id="'task' + task.id" :checked="task.checked" @click="toggleTask(task.id)" />
      <label style="color: #FF9900;">{{ task.hour }}</label>
      <label>{{ task.content }}</label>
      <!--opcjonalnie gwiazdka-->
      <div class="star-wrapper">
        <label class="star-label"><i class="fa-solid fa-star" style="color: #FF9900;"></i></label>
        <router-link to="/edit-task">
          <i class="fa-regular fa-pen-to-square" style="color: #8C8C8C; margin-left: 5px;"></i>
        </router-link>
        <i class="fa-solid fa-trash" style="color: #8C8C8C; margin-left: 7px;"></i>
      </div>
    </div>
    <Line />
  </div>
</template>
  
<script>
import Line from './Line.vue';
import { mapState } from 'vuex';

export default {
  components: {
    Line
  },
  computed: {
    ...mapState(['mode'])
  },
  props: {
    task: {
      type: Object,
      required: true
    }
  },
  methods: {
    toggleTask(taskId) {
      this.$emit('toggle-task', taskId);
    },
  },
};
</script>
  
<style>
.container1 {
  padding-left: 10%;
  padding-right: 10%;
  padding-top: 1%;
  padding-bottom: 1%;
}

.tick {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.tick label {
  margin: 3px;
}

.star-wrapper {
  flex-grow: 1;
  /* Nowy styl dla kontenera gwiazdki */
  text-align: right;
  /* Gwiazdka zostanie przesunięta na prawą stronę */
}

.star-label {
  display: inline-block;
  /* Zmieniamy styl na 'inline-block' */
}

.active-blue {
  color: #0099FF;
}

.active-green {
  color: #009900;
}
</style>
  