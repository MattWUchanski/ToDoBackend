<template>
    <div class="pomoc">
        <router-link to="/help">
            <a href="#" class="pomoc1" :class="mode + '-text'">Pomoc </a>
        </router-link>
        <i class="fa-solid fa-circle-question" :class="mode + '-icons'"></i>
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

<style>
    .pomoc1 {
        color: #009900; 
    }
    .pomoc1.green-text {
        color: #009900;
    }
    .pomoc1.blue-text {
        color: #0099FF;
    }
    
    .fa-circle-question {
        color: #009900;
    }
    .fa-circle-question.green-icons {
        color: #009900;
    }
    .fa-circle-question.blue-icons {
        color: #0099FF;
    }
    .pomoc {
        padding-top: 15%;
        padding-bottom: 8%;
        font-size: 150%;
        padding-left: 1%;
        padding-right: 1%;
    }
    .pomoc1:hover {
        text-decoration: none;
    }
</style>