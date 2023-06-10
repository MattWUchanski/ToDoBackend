<template>
    <div class="question1" style="color: #808080;">
        <div class="header">
        <div :class="{ 'active-blue': mode === 'blue', 'active-green': mode === 'green' }" class="title">
            Czy można dodać datę przeszłą?
        </div>
        <AngleDown @click="toggleElement"/>
        </div>
        <Line />
            <div class="answer" v-if="isVisible">W naszej aplikacji możemy oczywiście
            operować na dacie przeszłej dodając 
            w czasie przeszłym zadania oraz uzupełniająć
            je o ważne dla nas notatki. <br> <br>

            Aby to zrobić wystarczy ustawić się
            na interesującej nas dacie przeszłej
            i postępować jak w każdym innym przypadku, 
            gdy chcemy dodać zadanie i notatkę. <br> <br></div>
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
