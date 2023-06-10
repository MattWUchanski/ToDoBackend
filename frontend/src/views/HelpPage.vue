<template>
    <div class="navbar" :class="mode">
        <router-link to="/search">
            <button class="btn">
                <i class="fa-brands fa-searchengin"></i>
            </button>
        </router-link>

        <router-link to="/tasks">
            <button class="btn">
                <i class="fa fa-close"></i>
            </button>
        </router-link>
    </div>

    <div class="questions">  

        <Question1 :mode="mode" />

        <Question2 :mode="mode" />

        <Question3 :mode="mode" />

        <Question4 :mode="mode" />

        <Question5 :mode="mode" />
        
    </div>


</template>

<script>
    import Question1 from '../components/Question1.vue';
    import Question2 from '../components/Question2.vue';
    import Question3 from '../components/Question3.vue';
    import Question4 from '../components/Question4.vue';
    import Question5 from '../components/Question5.vue';
    import { mapState } from 'vuex';

    export default {
        components: {
        Question1,
        Question2,
        Question3,
        Question4,
        Question5,
      },
        computed: {
            ...mapState(['mode'])
        },
    };
</script>

<style scoped>
    .green {
        background-color: #009900;
    }
    .blue {
        background-color: #0099FF;
    }
    .btn {
        border: none;
        color: white !important;
        font-size: 200%;
        cursor: pointer;
    }
    .navbar {
        display: flex;
        justify-content: flex-end;
        align-items: center;
    }
    .questions {
    margin-left: auto;
    margin-right: auto;
    justify-content: center;
    padding-left: 10%;
    padding-right: 10%;
    padding-top: 5%;
   }
</style>