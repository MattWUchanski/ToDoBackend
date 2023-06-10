<template>
  <div>
    <NoteNavbar :mode="mode" />
  </div>
  <div class="container">
    <div class="opcje">
      <form action="">

        <div class="textarea">
          <input type="text" placeholder="Dodaj tytuł">
          <Line />
        </div>

        <div class="textarea">
          <textarea rows=6 maxlength="1000" placeholder="Zacznij pisać..."></textarea>
          <Line />
        </div>

        <div class="textarea">
          <p style="color: #a6a6a6; font-weight: 400;">Przypisz zadania, wybierając datę</p>
        </div>
        <div class="textarea">
          <input type="datetime-local" @change="updateDate($event)">
          <Line />
        </div>

        <div class="textarea">
          <input type="submit" value="Zapisz">
        </div>
      </form>

      <div class="OtherActivities" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">
        <Line />
        <p>Zadania przypisane do notatki:</p>
        <div>
          <div class="container1">
            <div class="tick" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">
              <input type="checkbox" @change="checked = $event.target.checked" />
              <label :style="{ color: checked ? '#a6a6a6' : '#FF9900' }">6:00</label>
              <label :style="{ color: checked ? '#a6a6a6' : (mode === 'blue' ? '#0099FF' : '#009900') }">Task 1</label>
              <div class="star-wrapper">
                <label class="star-label"><i class="fa-solid fa-star"
                    :style="{ color: checked ? '#a6a6a6' : '#FF9900' }"></i></label>
              </div>
            </div>

            <Line />
          </div>
        </div>

        <!--<div>
          <TaskToDo />
          <TaskDone />
        </div> pokazuje zadania przypisane do notatek, pokazując również czy są wykonane, czy nie-->

      </div>


    </div>
  </div>
</template>


<script>
//import TaskToDo from './TaskToDo.vue';
//import TaskDone from './TaskToDo.vue';
import Line from '../components/Line.vue';
import NoteNavbar from '../components/NoteNavbar.vue';
import { mapMutations, mapState } from 'vuex';

export default {
  components: {
    Line,
    // TaskToDo,
    //TaskDone,
    NoteNavbar,
  },
  computed: {
    // użyj funkcji mapState, aby pobierać wartość 'mode' z Vuex store
    ...mapState(['mode']),
  },
  data() {
    return {
      checked: false,
    };
  },

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
