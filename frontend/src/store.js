import { createStore } from 'vuex'

export default createStore({
  state: {
    mode: localStorage.getItem("mode") || "green",
    selectedDate: new Date().toLocaleDateString('pl-PL') // Domyślna data to dzisiaj
  },
  mutations: {
    setMode(state, mode) {
      state.mode = mode;
      localStorage.setItem("mode", mode);
    },
    setSelectedDate(state, date) { // Nowa mutacja do zmiany wybranej daty
      state.selectedDate = date;
    }
  },
  actions: {},
  modules: {}
})
