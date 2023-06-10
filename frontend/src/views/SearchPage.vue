<template>
    <div>
      <CloseNavbar :mode="mode">
        <template v-slot:search-input>
          <input type="text" placeholder="Search..." v-model="searchQuery" />
          <button class="btn" @click="search">
            <i class="fa-brands fa-searchengin"></i>
          </button>
        </template>
      </CloseNavbar>
  
      <div v-if="searchResults.length">
          <task v-for="task in searchResults.filter(item => item.type === 'task')" :key="task.id" :task="task" style="margin-top: 20px;"></task>
        <router-link to="/edit-note">
          <note v-for="note in searchResults.filter(item => item.type === 'note')" :key="note.id" :note="note" style="margin-top: 20px;"></note>
        </router-link>
      </div>
    </div> 
  </template>
  
  


<script>
  import CloseNavbar from '../components/CloseNavbar.vue';
  import Task from '../components/Task.vue';
  import Note from '../components/Note.vue';
  import { mapMutations, mapState } from 'vuex';

  export default {
      components: {
        CloseNavbar,
        Task,
        Note,
      },
      computed: {
    // użyj funkcji mapState, aby pobierać wartość 'mode' z Vuex store
    ...mapState(['mode'])
    },
    data() {
    return {
      items: [
        { type: 'note', id: 1, content: 'Notatka 1', keywords: ['klucz', 'notatka'] },
        { type: 'task', id: 2, content: 'Zadanie 1', keywords: ['klucz', 'zadanie'] },
      ],
      searchQuery: '',
      searchResults: []
    }
  },
  methods: {
    search() {
      this.searchResults = this.items.filter(item => {
        return item.keywords.includes(this.searchQuery)
      })
    },
  },
  };
</script>

<style scoped>
    input[type="text"] {
        height: 2rem;
        margin-left: 1rem;
    }
    .btn {
        border: none;
        color: white !important;
        font-size: 200%;
        cursor: pointer;
    }
  
</style>