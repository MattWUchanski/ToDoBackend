<template>
    <div class="question1" style="color: #808080;">
        <div class="header">
        <div :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }" class="title">
            Usuwanie notatek
        </div>
        <AngleDown @click="toggleElement"/>
        </div>
        <Line />
            <div class="answer" v-if="isVisible">W naszej aplikacji istnieje opcja, 
            aby usunąć notatki, które stały się 
            dla nas niepotrzebne. <br> <br>

            Wystarczy przejść do konkretnego zadania,
            zaznaczyć notatkę i wybrać opcję usuń. Po tej 
            operacji notatka przypisana do zadania zniknie. <br> <br></div>
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
