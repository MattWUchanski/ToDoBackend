<template>
  <div>
    <TaskViewNavbar :mode="mode" />
  </div>
  <div class="container">
    <div class="opcje">
      <form action="">

        <div class="star-checkbox">
          <input type="checkbox" id="starCheckbox" v-model="checked" />
          <label for="starCheckbox">
            <i class="fas fa-star" :style="{ 'color': checked ? '#ffcc00' : 'inherit' }"></i>
          </label>
        </div>

        <div class="textarea">
          <input type="text" placeholder="Dodaj tytuł">
          <Line />
        </div>

        <div class="textarea">
          <input type="datetime-local" @change="updateDate($event)">
          <Line />
        </div>

        <div class="textarea">
          <textarea rows=4 maxlength="300" placeholder="Opis"></textarea>
          <Line />
        </div>

        <div class="textarea">
          <input type="search" placeholder="Przypisz notatki">
          <Line />
        </div>

        <div class="textarea">
          <input type="submit" value="Zapisz">
        </div>
      </form>

      <div class="OtherActivities" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">
        <Line />
        <p>{{ dateToShow }} - inne plany na wybrany dzień:</p>

        <div v-for="task in tasksForDate()" :key="task.id">
          <TaskToDo v-if="!task.checked" :task="task" />
          <TaskDone v-else :task="task" />
        </div>

      </div>


    </div>
  </div>
</template>


<script>
import TaskToDo from '../components/TaskToDo.vue';
import TaskDone from '../components/TaskToDo.vue';
import Line from '../components/Line.vue';
import TaskViewNavbar from '../components/TaskViewNavbar.vue';
import { mapMutations, mapState } from 'vuex';

export default {
  components: {
    Line,
    TaskToDo,
    TaskDone,
    TaskViewNavbar
  },
  computed: {
    // użyj funkcji mapState, aby pobierać wartość 'mode' z Vuex store
    ...mapState(['mode']),
  },
  data() {
    return {
      dateToShow: '',
      dateToShow: '',
      checked: false,
      tasks: [
        { id: 1, checked: true, content: 'Task 1', hour: '6:00', date: '25.05.2023' },
        { id: 2, checked: false, content: 'Task 2', hour: '7:00', date: '26.05.2023' },
        { id: 3, checked: false, content: 'Task 3', hour: '8:00', date: '27.05.2023' },
      ],
    };
  },
  methods: {
    // ...
    updateDate(event) {
      let date = new Date(event.target.value);
      this.dateToShow = date.toLocaleDateString();
    },
    tasksForDate() {
      return this.tasks.filter(task => task.date === this.dateToShow);
    }
  }
};
</script>

<style scoped>
.opcje {
  padding-top: 7%;
  padding-bottom: 5%;
  padding-left: 15%;
  padding-right: 15%;
}

input {
  color: #A6A6A6;
  border: none;
}

.textarea {
  margin: 20px;
  font-size: 110%;
}

textarea {
  color: #A6A6A6;
  border: 1px #F2F2F2;
  width: 100%;
}

.OtherActivities {
  margin-top: 5px;
}

.star-checkbox input[type="checkbox"] {
  display: none;
}

.star-checkbox label {
  display: inline-block;
  color: #A6A6A6;
  cursor: pointer;
}


.active-blue {
  color: #0099FF;
}

.active-green {
  color: #009900;
}

p {
  font-size: 110%;
  font-weight: bold;
  margin-top: 10px;
  margin-bottom: 10px;
}

/*.container1 {
padding-left: 10%;
padding-right: 10%;
padding-top: 1%;
padding-bottom: 1%;
}*/</style>
