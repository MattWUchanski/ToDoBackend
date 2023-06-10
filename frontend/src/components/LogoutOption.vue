<template>
    <div class="wyloguj">
        <a href="#" class="wyloguj1" :class="mode + '-text'">Wyloguj </a>
        <i class="fa-solid fa-right-from-bracket" :class="mode + '-icons'"></i>
        <Line />
    </div>
</template>

<script>
    import Line from './Line.vue';
    import { mapState } from 'vuex';

    export default {
        components: {
            Line,
        },
        computed: {
            ...mapState(['mode'])
        }
    };
</script>

<style scoped>
    .wyloguj1 {
        color: #009900; 
    }
    .wyloguj1.green-text {
        color: #009900;
    }
    .wyloguj1.blue-text {
        color: #0099FF;
    }
    .fa-right-from-bracket {
        color: #009900; 
    }
    .fa-right-from-bracket.green-icons {
        color: #009900;
    }
    .fa-right-from-bracket.blue-icons {
        color: #0099FF;
    }
    .wyloguj {
        padding-top: 15%;
        padding-bottom: 8%;
        font-size: 150%;
        padding-left: 1%;
        padding-right: 1%;
    }
    .wyloguj1:hover {
        text-decoration: none;
    }
</style>