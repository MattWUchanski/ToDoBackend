<template>
  <div>
      <NotesNavbar :mode="mode" />
  </div>

  <div class="container">
      <div class="notes">
          <div class="notes-wrapper">
            <router-link to="/edit-note"><div class="note col-12 col-lg-4"><NoteView /></div></router-link>
            <router-link to="/edit-note"><div class="note col-12 col-lg-4"><NoteView /></div></router-link>
            <router-link to="/edit-note"><div class="note col-12 col-lg-4"><NoteView /></div></router-link>
          </div>
      </div>
  </div>

  <div class="circle-plus-wrapper">
      <router-link to="/new-note">
        <i class="fa-solid fa-circle-plus" :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }"></i>
      </router-link>
  </div>
</template>

<script>
import NotesNavbar from '../components/NotesNavbar.vue';
import NoteView from '../components/NoteView.vue';
import { mapState } from 'vuex';

export default {
    components: {
      NotesNavbar,
      NoteView,
    },
    computed: {
      ...mapState(['mode', 'selectedDate']),
    }
};
</script>

<style scoped>
.green {
  background-color: #009900;
}
.blue {
  background-color: #0099FF;
}
.notes {
  padding-top: 5%;
  padding-bottom: 5%;
  padding-left: 5%;
  padding-right: 5%;
}
.notes-wrapper {
  display: flex; 
  flex-wrap: wrap; 
  justify-content: center; /* Dodane, aby wyśrodkować divy */
  margin: 0;
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

.active-blue {
  color: #0099FF;
}

.active-green {
  color: #009900;
}

</style>
