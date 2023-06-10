<template>
    <div class="question1" style="color: #808080;">
        <div class="header">
        <div :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }" class="title">
            Wylogowanie się z aplikacji
        </div>
        <AngleDown @click="toggleElement"/>
        </div>
        <Line />
            <div class="answer" v-if="isVisible">Aby wylogować się z aplikacji
            musimy przejść do ekranu opcji, które znajdują 
            się w prawym górnym rogu strony głównej
            pod ikonką trzech kropek. <br> <br>

            Następnie na samym dole listy
            znajdziemy opcję Wyloguj. Po wybraniu
            zostanie zamknięta sesja dla danego 
            użytkownika. Przy kolejnej próbie korzystania
            z aplikacji użytkownik będzie musiał
            zalogować się ponownie. <br> <br></div>
    </div>
</template>

<script>
    import Line from './Line.vue';
    import AngleDown from './AngleDown.vue';
    import { mapState } from 'vuex';

      export default {
        components: {
        Line,
        AngleDown,
        },
        data() {
        return {
            isVisible: false
        };
        },
        computed: {
        ...mapState(['mode']),
        },
        methods: {
        toggleElement() {
        this.isVisible = !this.isVisible;
    }
  }
};
</script>

<style scoped>
    .active-blue {
        color: 0099FF;
    }
    .active-green {
        color: 009900;
    }
    .header {
        display: flex;
        font-size: 180%;
    }
    .answer {
        font-size: 120%;
    }
    .title {
        background-color: white; 
        width: 100%;       
    }
</style>
