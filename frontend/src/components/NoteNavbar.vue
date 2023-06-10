<template>
    <div class="navbar" :class="mode">
        <slot name="search-input"></slot>
        <router-link to="/notes">
            <button class="btn" @click.prevent="showAlert">
                <i class="fa fa-close"></i>
            </button>
        </router-link>
    </div>
</template>

<script>
    import { mapState } from 'vuex';

    export default {
            computed: {
            ...mapState(['mode'])
        },
        methods: {
            showAlert(event) {
                if (!confirm("Czy na pewno chcesz opuścić edycję notatki bez zapisu?")) {
                    event.preventDefault();
                } else {
                    this.$router.push('/notes');
                }
            },
        },
    };
</script>

<style scoped>
    .navbar {
        display: flex;
        justify-content: flex-end;
        align-items: center;
    }
    .btn {
        border: none;
        color: white !important;
        font-size: 200%;
        cursor: pointer;
    }
    .green {
        background-color: #009900;
    }
    .blue {
        background-color: #0099FF;
    }
</style>