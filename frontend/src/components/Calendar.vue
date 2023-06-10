<template>
    <div id="calendar">
      <h2>{{ getMonthName(currentMonth) }} {{ currentYear }}</h2>
      <div class="btn-group">
        <button @click="showPreviousMonth()" class="btn" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">Poprzedni</button>
        <button @click="showNextMonth()" class="btn" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }">Następny</button>
      </div>
      <select v-model="currentYear" @change="createCalendar()">
        <option v-for="year in yearRange" :key="year" :value="year">{{ year }}</option>
      </select>
      <table>
        <tr>
          <th v-for="weekday in weekdays" :key="weekday">{{ weekday }}</th>
        </tr>
        <tr v-for="week in weeks" :key="week.id">
          <!--<td v-for="day in week.days" :key="day.date" :class="{ 'current-day': isToday(day), 'selected-day': day.selected }" @click="selectDay(day)">
            {{ day.date }}
          </td>-->
          <td v-for="day in week.days" :key="day.date"
          :class="[
              isToday(day) ? 'current-day' : '',
              day.selected ? 'selected-day' : '',
              isToday(day) && mode === 'blue' ? 'active-blue' : '',
              isToday(day) && mode === 'green' ? 'active-green' : '',
              day.selected && mode === 'blue' ? 'active-blue' : '',
              day.selected && mode === 'green' ? 'active-green' : '',
          ]"
          @click="selectDay(day)">
          {{ day.date }}
      </td>
      

        </tr>
      </table>
    </div>
  </template>
  
  <script>
  import { mapState } from 'vuex';
  export default {
    data() {
      return {
        currentYear: new Date().getFullYear(),
        currentMonth: new Date().getMonth(),
        selectedDay: null,
        weekdays: ["Nd", "Pon", "Wt", "Śr", "Czw", "Pt", "Sob"],
        weeks: [],
      };
    },
    computed: {
        ...mapState(['mode']),
      yearRange() {
        let years = [];
        for (let i = 2023; i <= 2030; i++) {
          years.push(i);
        }
        return years;
      }
    },
    methods: {
      getMonthName(month) {
        var months = [
          "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec",
          "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"
        ];
        return months[month];
      },
      showPreviousMonth() {
        if (this.currentMonth === 0) {
          this.currentYear--;
          this.currentMonth = 11;
        } else {
          this.currentMonth--;
        }
        this.createCalendar();
      },
      showNextMonth() {
        if (this.currentMonth === 11) {
          this.currentYear++;
          this.currentMonth = 0;
        } else {
          this.currentMonth++;
        }
        this.createCalendar();
      },
      isToday(day) {
        let today = new Date();
        return day.date === today.getDate() && this.currentMonth === today.getMonth() && this.currentYear === today.getFullYear();
      },
      selectDay(day) {
        /*if (this.selectedDay) {
          this.selectedDay.selected = false;
        }
        day.selected = true;
        this.selectedDay = day;*/
        if (this.selectedDay) {
          this.selectedDay.selected = false;
        }
        day.selected = true;
        this.selectedDay = day;

        // Zaktualizuj wybraną datę w store
        let selectedDate = new Date(this.currentYear, this.currentMonth, day.date).toLocaleDateString('pl-PL');
        this.$store.commit('setSelectedDate', selectedDate);
      },
      createCalendar() {
        this.weeks = [];
        let firstDay = new Date(this.currentYear, this.currentMonth, 1);
        let startingDay = firstDay.getDay();
        let daysInMonth = new Date(this.currentYear, this.currentMonth + 1, 0).getDate();
        let date = 1;
        for (let row = 0; row < 6; row++) {
          let week = { id: row, days: [] };
          for (let col = 0; col < 7; col++) {
            if (row === 0 && col < startingDay) {
              week.days.push({ date: null });
            } else if (date > daysInMonth) {
              break;
            } else {
              week.days.push({ date: date, selected: false });
              date++;
            }
          }
          this.weeks.push(week);
        }
      },
    },
    mounted() {
      this.createCalendar();
    },
  };
  </script>
  
  <style scoped>
    #calendar {
      font-family: Arial, sans-serif;
      width: 400px;
      padding: 20px;
      border: 1px solid #F2F2F2;
      /*background-color: #f9f9f9;*/
      background-color: transparent;
    }

    h2 {
      text-align: center;
    }
  
    table {
      width: 100%;
    }
  
    th, td {
      text-align: center;
      padding: 5px;
      cursor: pointer;
    }
  
    /*.current-day {
      color: white;
    }*/
  
    /*.selected-day {
        background-color: #009900;
    }*/
    .btn {
      display: inline-block;
      padding: 5px 10px;
      margin-right: 10px;
     
      color: white;
      text-decoration: none;
      border-radius: 4px;
      cursor: pointer;
    }
  
    .btn.active-blue:hover {
      background-color: #0099FF;
    }
    .btn.active-green:hover {
        background-color: #45a049;
      }
    .btn-group {
      margin-bottom: 10px;
    }
    .active-blue {
        background-color: #0099FF;
        color: white;
    }
    
    .active-green {
        background-color: #009900;
        color: white;
    }


    .current-day.active-blue {
        background-color: #0099FF;
        color: white !important;
    }
    
    .current-day.active-green {
        background-color: #009900;
        color: white !important;
    }
    
    .selected-day.active-blue {
        background-color: #0099FF;
        color: black;
    }
    
    .selected-day.active-green {
        background-color: #009900;
        color: black;
    }
    

    
  </style>
  