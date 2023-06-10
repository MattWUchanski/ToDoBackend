<template>
  <div class="container">
    <div class="note">
      {{ note.content }}
    </div>
  </div>

  </template>
  
  <script>
  import { mapState } from 'vuex';
  export default {
    props: {
      note: {
        type: Object,
        required: true
      }
    },
    computed: {
    ...mapState(['mode'])
    },
  };
  </script>
  
  <style scoped>
  .note {
    border: 1px solid #A6A6A6; 
    border-radius: 15px;
    color: #A6A6A6;
    width: 290px;
    height: 150px;
    padding: 10px;
    margin: 5px;
}
  </style>
  