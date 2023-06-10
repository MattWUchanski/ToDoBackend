<template>
  <div>
    <TaskNavbar :mode="mode" />

    <div class="container">
      <div class="calendar-container">
        <Calendar />
      </div>

      <div class="current-date" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">
        <h3>{{ selectedDate }}</h3>
      </div>

      <div v-for="(task, index) in tasksForSelectedDate" :key="index" class="test21">
        <component :is="task.taskIsComplete ? 'TaskDone' : 'TaskToDo'" :task="task" @toggle-task="toggleTask">
          <div class="task-info">
            <h4>{{ task.taskTitle }}</h4>
            <p>{{ task.taskId }}</p>
          </div>
        </component>
      </div>
    </div>

    <div class="circle-plus-wrapper">
      <router-link to="/new-task">
        <i class="fa-solid fa-circle-plus"
          :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }"></i>
      </router-link>
    </div>
  </div>
</template>


<script>
import axios from 'axios'; // Don't forget to install this with npm install axios
import Calendar from '../components/Calendar.vue';
import TaskNavbar from '../components/TaskNavbar.vue';
import TaskToDo from '../components/TaskToDo.vue';
import TaskDone from '../components/TaskDone.vue';
import { mapState } from 'vuex';

export default {
  components: {
    TaskNavbar,
    Calendar,
    TaskToDo,
    TaskDone,
  },
  computed: {
    ...mapState(['mode', 'selectedDate']),
    tasksForSelectedDate() {
      return this.tasks;
    }
  },
  data() {
    return {
      tasks: []
    }
  },
  methods: {
    pad(n) {
      return n < 10 ? '0' + n : n;
    },
    toggleTask(taskId) {
      const task = this.tasks.find(task => task.TaskId === taskId);
      if (task) {
        task.taskIsComplete = !task.taskIsComplete;
      }
    },
  },
  watch: {
    selectedDate() {
      if (this.selectedDate) {
        let parts = this.selectedDate.split(".");
        let formattedDate = new Date(parts[2], parts[1] - 1, parts[0]).toISOString().split('T')[0];
        console.log(formattedDate);

        axios.get(`https://localhost:5001/api/ToDoTasks/ByDate/${formattedDate}`)
          .then(response => {
            this.tasks = response.data.map(task => {
              let taskDate = new Date(task.taskDate);
              task.TaskDate = ('0' + taskDate.getDate()).slice(-2) + '.' + ('0' + (taskDate.getMonth() + 1)).slice(-2) + '.' + taskDate.getFullYear();
              task.taskIsComplete = task.taskIsComplete;
              task.id = task.taskId;
              task.content = task.taskTitle;

              // Extract hours and minutes from taskTime.totalHours and taskTime.totalMinutes
              let taskHours = Math.floor(task.taskTime.totalHours);
              let taskMinutes = Math.floor((task.taskTime.totalHours - taskHours) * 60);

              task.taskTime = { hours: taskHours, minutes: taskMinutes };

              return task;
            });
          })
          .catch(error => {
            console.error(error);
          });

      } else {
        this.tasks = [];
      }
    }
  }

};
</script>



<style scoped>
.test21 {
  font-size: 20px;
}

.green {
  background-color: #009900;
}

.blue {
  background-color: #0099FF;
}

.calendar-container {
  display: flex;
  justify-content: center;
  margin-top: 10px;
}

.current-date {
  padding-left: 10%;
  padding-right: 10%;
  padding-top: 3%;
  padding-bottom: 1%;
}

.active-blue {
  color: #0099FF;
}

.active-green {
  color: #009900;
}

.circle-plus-wrapper {
  position: fixed;
  bottom: 20px;
  right: 20px;
  z-index: 999;
}

.fa-circle-plus {
  font-size: 50px;
}
</style>