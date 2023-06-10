<template>
    <div class="navbar ml-5" :class="mode">
        <div class="container-fluid">
            <div class="left-buttons">
                <h4>ToDoTog</h4>
            </div>
            <div class="right-buttons">
                <button class="btn" @click="showAlert">
                    <i class="fa-solid fa-ellipsis-vertical"></i>
                </button>
            </div>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex';
export default {

    data() {
        return {
            isSearchBarVisible: false
        };
    },
    computed: {
        ...mapState(['mode'])
    },
    methods: {
        showAlert() {
            alert("Musisz być zalogowany, aby mieć dostęp do ustawień kolorów!");
        },
    },
};
</script>

<style scoped>
.navbar {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.btn {
    border: none;
    color: white !important;
    font-size: 200%;
    cursor: pointer;
}

.btn-1 {
    font-size: 150%;
    border: 2px solid white;
    background-color: transparent;
    color: white;
    font-size: 150%;
    cursor: pointer;
    margin-right: 1rem;
}

.active-blue {
    background-color: white;
    color: #0099FF;
}

.active-green {
    background-color: white;
    color: #009900;
}

.navbar h4 {
    color: white;
}
</style>
